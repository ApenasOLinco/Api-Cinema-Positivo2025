import * as requestService from "./RequestService.js";

const FETCH_URL = `${requestService.API_URL}/api/v1/Ator`;

export async function todosOsAtores() {
	const atores = await requestService._get(FETCH_URL);

	return atores;
}

export async function umAtor(id) {
	const ator = await requestService._get(`${FETCH_URL}/${id}`);

	return ator;
}

export async function deletarAtor(id) {
	const foiDeletado = await requestService._delete(`${FETCH_URL}/${id}`);

	return foiDeletado;
}