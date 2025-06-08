import * as fetchService from "./FetchService.js";

const FETCH_URL = `${fetchService.API_URL}/api/v1/Filmes`;

export async function todosOsFilmes() {
	const filmes = await fetchService.get(FETCH_URL);

	return filmes;
}

export async function umFilme(id) {
	const filme = await fetchService.get(`${FETCH_URL}/${id}`)
	return filme;
}