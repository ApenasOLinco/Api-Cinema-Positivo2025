import * as requestService from "./RequestService.js";

const FETCH_URL = `${requestService.API_URL}/api/v1/Diretor`;

export async function todosOsDiretores() {
	const diretores = await requestService._get(FETCH_URL);

	return diretores;
}

export async function umDiretor(id) {
	const diretor = await requestService._get(`${FETCH_URL}/${id}`);

	return diretor;
}

export async function deletarDiretor(id) {
	const foiDeletado = await requestService._delete(`${FETCH_URL}/${id}`);

	return foiDeletado;
}