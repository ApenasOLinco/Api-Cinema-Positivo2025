import { umAtor } from "./service/AtorService.js";
import { appendHr, createLi } from "./util.js";

const ENV = await fetch("/resources/env.json")
.then(resp => resp.json())

const FETCH_URL = `${ENV.api_url}/api/v1/Filmes`;

async function carregarAtor() {
	const id = new URLSearchParams(window.location.search).get("id");
	const erro = document.createElement('h3');

	if (!id || id === "") {
		erro.innerText = "Ops! Página errada? O Id informado é inválido :/"
		document.body.appendChild(erro);
		return;
	}

	const ator = await umAtor(id);

	document.title += `: ${ator.nome} (Ator)`;

	const nome = document.createElement('h2');
	nome.innerText = ator.nome;
	document.body.appendChild(nome);

	appendHr();

	const detalhes = document.createElement('ul');
	createLi(detalhes).innerHTML = `<strong>Data de Nascimento:</strong> ${ator.dataNasc.toString()}`
	document.body.appendChild(detalhes);
}

carregarAtor();
