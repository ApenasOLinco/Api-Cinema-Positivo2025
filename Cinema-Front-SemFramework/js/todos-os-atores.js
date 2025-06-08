import { todosOsAtores } from "./service/AtorService.js";

const atores = await todosOsAtores();

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
	document.body.appendChild(clone)
});
