import * as service from "./service/AtorService.js";

const atores = await service.todosOsAtores();

// Obter template
const cartao_template = document.querySelector("#cartao-template");

atores.forEach(ator => {
	// Modificar o template antes de criar o elemento novo efetivamente
	const atorSummary = cartao_template.content.querySelector(".cartao-summary");
	atorSummary.querySelector("h3").innerHTML = `<a href="./ator.html?id=${ator.id}">${ator.nome}</a>`;

	const atorInfo = cartao_template.content.querySelector(".cartao-info");
	const info = atorInfo.querySelector("tbody > tr > td");
	info.innerHTML = ator.dataNasc;

	let clone = document.importNode(cartao_template.content, true);
	clone.querySelector(".cartao").id = `ator-${ator.id}`;

	const btn_deletar = clone.querySelector('.btn-deletar');
	btn_deletar.addEventListener('click', async (e) => {

		if (service.deletarAtor(ator.id)) {
			alert(`ator ${ator.nome} deletado com sucesso.`);
			document.querySelector(`#ator-${ator.id}`).remove();
			return;
		}

		alert(`Não foi possível deletar o ator.`);

	});
	document.body.appendChild(clone)
});
