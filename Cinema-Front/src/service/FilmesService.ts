import type FilmeGetResponse from "../models/Filme/FilmeGetResponse";

const API_URL = import.meta.env.VITE_API_URL;

export default async function TodosOsFilmes(): Promise<FilmeGetResponse[]> {
	const response = await fetch(
		`${API_URL}/api/v1/Filmes`,
		{
			method: 'GET',
			mode: 'cors',
		}
	)

	if (!response.ok) {
		throw new Error(`Erro ${response.status}: ${response.statusText}`)
	}

	const filmes = await response.json();

	return filmes;
}