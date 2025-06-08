import { umDiretor } from "./service/DiretorService.js";
import { appendHr, createLi } from "./util.js";

async function carregarDiretor() {
	const id = new URLSearchParams(window.location.search).get("id");
	const erro = document.createElement('h3');

	if (!id || id === "") {
		erro.innerText = "Ops! Página errada? O Id informado é inválido :/"
		document.body.appendChild(erro);
		return;
	}

	const diretor = await umDiretor(id);

	document.title += `: ${diretor.nome} (Diretor)`;

	const nome = document.createElement('h2');
	nome.innerText = diretor.nome;
	document.body.appendChild(nome);

	
	if(diretor.biografia) {
		appendHr();

		const biografia = document.createElement('p');
		biografia.innerText = diretor.biografia
		document.body.appendChild(biografia);
	}

	appendHr();

	const detalhes = document.createElement('ul');
	createLi(detalhes).innerHTML = `<strong>Data de Nascimento:</strong> ${diretor.dataNasc.toString()}`
	document.body.appendChild(detalhes);
}

carregarDiretor();