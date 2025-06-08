import * as fetchService from "./FetchService.js";

const FETCH_URL = `${fetchService.API_URL}/api/v1/Diretor`;

export async function todosOsDiretores() {
	const diretores = await fetchService.get(FETCH_URL);

	return diretores;
}

export async function umDiretor(id) {
	const diretor = await fetchService.get(`${FETCH_URL}/${id}`);

	return diretor;
}