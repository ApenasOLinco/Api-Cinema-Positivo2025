import { useEffect, useState } from "react";
import TodosOsFilmes from "../../service/FilmesService";
import type FilmeGetResponse from "../../models/Filme/FilmeGetResponse";
import CartaoFilme from "../../components/CartaoFilme";

function Home() {
	const [filmes, setFilmes] = useState<FilmeGetResponse[]>([]);

	useEffect(() => {
		TodosOsFilmes().then((filmes) => setFilmes(filmes))
	}, []);

	return (
		<div className="home">
			<ul>
				{filmes.map(filme => (
					<CartaoFilme filme={filme} key={filme.id} />
				))}
			</ul>
		</div>
	);
}

export default Home;