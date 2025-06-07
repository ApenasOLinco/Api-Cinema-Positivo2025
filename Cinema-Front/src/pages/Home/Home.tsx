import { useEffect, useState } from "react";
import { TodosOsFilmes } from "../../service/FilmesService";
import type FilmeGetResponse from "../../models/Filme/FilmeGetResponse";
import CartaoFilme from "../../components/CartaoFilme";
import BarraPesquisa from "../../components/BarraPesquisa";

function Home() {
	const [filmes, setFilmes] = useState<FilmeGetResponse[]>([]);
	const [query, setQuery] = useState("");
	const [carregando, setCarregando] = useState(false);
	const [erro, setErro] = useState<string | null>(null);

	useEffect(() => {
		const carregarFilmes = async () => {
			setCarregando(true);

			try {
				const filmesDados = await TodosOsFilmes();
				setFilmes(filmesDados);
			} catch (erro) {
				if (erro instanceof Error) setErro(erro.message);
			} finally {
				setCarregando(false);
			}
		};

		carregarFilmes();
	}, []);

	const handlePesquisaChange = (texto: string) => {
		setQuery(texto);
	}

	if (carregando) return <h3>Carregando...</h3>

	if (erro) return <h3>Erro: {erro}</h3>

	return (
		<>
			<BarraPesquisa onChange={handlePesquisaChange} />

			{/** Um filme só é listado se seu título começar com o texto da pesquisa */}
			{filmes.map(filme => (
				filme.titulo.toLowerCase().startsWith(query.toLowerCase())
				&&
				<div key={filme.id}>
					<CartaoFilme filme={filme} />
					<hr />
				</div>
			))}
		</>
	);
}

export default Home;