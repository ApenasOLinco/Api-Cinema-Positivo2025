import * as fetchService from "./FetchService.js";

const FETCH_URL = `${fetchService.API_URL}/api/v1/Atores`;

export async function todosOsAtores() {
	const atores = await fetchService.get(FETCH_URL);

	return atores;
}

export async function umAtor(id) {
	const ator = await fetchService.get(`${FETCH_URL}/${id}`);

	return ator;
}