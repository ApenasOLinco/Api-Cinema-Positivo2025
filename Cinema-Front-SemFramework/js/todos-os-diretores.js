import * as service from "./service/DiretorService.js";

const diretores = await service.todosOsDiretores();

// Obter template
const cartao_template = document.querySelector("#cartao-template");

diretores.forEach(diretor => {
	// Modificar o template antes de criar o elemento novo efetivamente
	const diretorSummary = cartao_template.content.querySelector(".cartao-summary");

	// Nome do diretor
	diretorSummary.querySelector("h3").innerHTML = `<a href="./diretor.html?id=${diretor.id}">${diretor.nome}</a>`;

	// Biografia
	diretorSummary.querySelector('p').innerHTML = diretor.biografia || "";

	const diretorInfo = cartao_template.content.querySelector(".cartao-info");
	const info = diretorInfo.querySelector("tbody > tr > td");
	info.innerHTML = diretor.dataNasc;

	let clone = document.importNode(cartao_template.content, true);
	clone.querySelector(".cartao").id = `diretor-${diretor.id}`;

	const btn_deletar = clone.querySelector('.btn-deletar');
	btn_deletar.addEventListener('click', async (e) => {

		if (service.deletarDiretor(diretor.id)) {
			alert(`diretor ${diretor.nome} deletado com sucesso.`);
			document.querySelector(`#diretor-${diretor.id}`).remove();
			return;
		}

		alert(`Não foi possível deletar o diretor.`);

	});
	document.body.appendChild(clone)
});
