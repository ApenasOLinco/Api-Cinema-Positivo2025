import * as service from "./service/FilmesService.js";

const filmes = await service.todosOsFilmes();

// Obter template
const cartao_template = document.querySelector("#cartao-template");

filmes.forEach(filme => {
	// Modificar o template antes de criar o elemento novo efetivamente
	const filmeSummary = cartao_template.content.querySelector(".cartao-summary");
	filmeSummary.querySelector("h3").innerHTML = `<a href="./filme.html?id=${filme.id}">${filme.titulo}</a>`;
	filmeSummary.querySelector("p").innerText = filme.sinopse;

	const filmeInfo = cartao_template.content.querySelector(".cartao-info");
	const infos = filmeInfo.querySelectorAll("tbody > tr > td");
	infos[0].innerText = filme.diretor.nome;
	infos[1].querySelector('ul').innerHTML = filme.generos.map(g => `<li>${g}</li>`).join("");

	
	let clone = document.importNode(cartao_template.content, true);
	clone.querySelector(".cartao").id = `filme-${filme.id}`;

	const btn_deletar = clone.querySelector('.btn-deletar');
	btn_deletar.addEventListener('click', async (e) => {
		
		if(service.deletarFilme(filme.id)) {
			alert(`Filme ${filme.titulo} deletado com sucesso.`);
			document.querySelector(`#filme-${filme.id}`).remove();
		}

	});
	
	document.body.appendChild(clone);
});
