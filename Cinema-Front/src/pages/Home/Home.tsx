import { useEffect, useState } from "react";
import { TodosOsFilmes } from "../../service/FilmesService";
import type FilmeGetResponse from "../../models/Filme/FilmeGetResponse";
import CartaoFilme from "../../components/CartaoFilme";
import BarraPesquisa from "../../components/BarraPesquisa";

function Home() {
	const [filmes, setFilmes] = useState<FilmeGetResponse[]>([]);
	const [query, setQuery] = useState("");

	useEffect(() => {
		TodosOsFilmes().then((filmes) => setFilmes(filmes))
	});

	const handlePesquisaChange = (texto: string) => {
		setQuery(texto);
	}

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