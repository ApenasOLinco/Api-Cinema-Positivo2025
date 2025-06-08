import * as requestService from "./requestService.js";

const FETCH_URL = `${requestService.API_URL}/api/v1/Ator`;

export async function todosOsAtores() {
	const atores = await requestService.get(FETCH_URL);

	return atores;
}

export async function umAtor(id) {
	const ator = await requestService.get(`${FETCH_URL}/${id}`);

	return ator;
}