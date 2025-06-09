import * as requestService from "./RequestService.js";

const FETCH_URL = `${requestService.API_URL}/api/v1/Filmes`;

export async function todosOsFilmes() {
	const filmes = await requestService._get(FETCH_URL);

	return filmes;
}

export async function umFilme(id) {
	const filme = await requestService._get(`${FETCH_URL}/${id}`)
	return filme;
}

export async function deletarFilme(id) {
	const foiDeletado = await requestService._delete(`${FETCH_URL}/${id}`);

	return foiDeletado;
}

export async function novoFilme(filme) {
	const resposta = await requestService._post(filme);

	return resposta.ok;
}