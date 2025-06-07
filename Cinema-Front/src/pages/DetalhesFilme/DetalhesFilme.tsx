import { useParams } from "react-router-dom";
import { UmFilme } from "../../service/FilmesService";
import { useEffect, useState } from "react";
import type FilmeGetResponse from "../../models/Filme/FilmeGetResponse";

function DetalhesFilme() {
	const [filme, setFilme] = useState<FilmeGetResponse>();
	const [carregando, setCarregando] = useState(false);
	const [erro, setErro] = useState<string | null>();

	let { id } = useParams();
	id = id || '-1';

	useEffect(() => {
		const carregarFilme = async () => {
			setCarregando(true);

			try {
				const filmeDados = await UmFilme(id);
				setFilme(filmeDados);
			} catch (erro) {
				if (erro instanceof Error) setErro(erro.message);
			} finally {
				setCarregando(false);
			}
		};

		carregarFilme();
	}, [id]);

	if (carregando) return <h3>Carregando...</h3>;

	if (erro) return <h3>Erro: {erro}</h3>

	if (filme) document.title = filme.titulo;

	return (
		filme &&
		<>
			<img src="/images/placeholder-image.png" alt={`Poster do filme ${filme.titulo}`} />

			<h1 className="titulo">{filme.titulo} ({filme.anoLancamento})</h1>
			<ul className="generos">
				{filme.generos.map((genero, index) => (
					<li key={index}>{genero}</li>
				))}
			</ul>

			<p>Nota no IMDB: {filme.notaIMDB}</p>

			<p className="sinopse">{filme.sinopse}</p>

			<h2>Diretor</h2>
			<ul>
				<li>Nome: {filme.diretor.nome}</li>
				<li>Data de nascimento: {new Date(filme.diretor.dataNasc).toLocaleDateString('pt-BR')}</li>
				{
					filme.diretor.biografia
					&&
					<p className="biografia">{filme.diretor.biografia}</p>
				}
			</ul>

			<h2>Elenco</h2>
			<ul>
				{filme.atores.map(atorPapel => (
					<li>
						{atorPapel.ator.nome} como {atorPapel.papel}
					</li>
				))}
			</ul>
		</>
	);
}

export default DetalhesFilme;