import { useEffect, useState } from "react";
import TodosOsFilmes from "../service/FilmesService";
import type FilmeGetResponse from "../models/Filme/FilmeGetResponse";

function Home() {
	const [filmes, setFilmes] = useState<FilmeGetResponse[]>([]);

	useEffect(() => {
		TodosOsFilmes().then((filmes) => setFilmes(filmes))
	}, []);

	return (
		<div className="home">
			<h1>FILMIFY</h1>
		</div>
	);
}

export default Home;