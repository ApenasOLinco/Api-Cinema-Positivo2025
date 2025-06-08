const ENV = await fetch("/resources/env.json")
	.then(resp => resp.json());

export const API_URL = ENV.api_url;

export async function get(url) {
	const resposta = await fetch(
		url,
		{
			method: 'GET',
			mode: 'cors'
		}
	);

	if (!resposta.ok) {
		console.error(`Erro ${resposta.status}: ${resposta.statusText}`);
		return;
	}

	return await resposta.json();
}
