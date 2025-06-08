import { todosOsDiretores } from "./service/DiretorService.js";

const diretores = await todosOsDiretores();

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
	document.body.appendChild(clone)
});
