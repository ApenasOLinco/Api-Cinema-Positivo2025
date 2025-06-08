const ENV = await fetch("/resources/env.json")
	.then(resp => resp.json());

export const API_URL = ENV.api_url;

export async function _get(url) {
	const resposta = await fetch(
		url,
		{
			method: 'GET',
			mode: 'cors'
		}
	);

	if (!resposta.ok) {
		throw new Error(`Erro ${resposta.status}: ${resposta.statusText}`);
	}

	return await resposta.json();
}

export async function _delete(url) {
	const resposta = await fetch(
		url,
		{
			method: 'DELETE',
			mode: 'cors'
		}
	)

	return resposta;
}
