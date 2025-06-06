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
		<>
			{/* Listagem dos filmes */}
			{filmes.map(filme => (
				<div key={filme.id}>
					<CartaoFilme filme={filme} />
					<hr />
				</div>
			))}
		</>
	);
}

export default Home;