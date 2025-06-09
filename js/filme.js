import * as service from "./service/FilmesService.js";
import { appendHr, createLi } from "./util.js";

async function carregarFilme() {
	const id = new URLSearchParams(window.location.search).get("id");
	const erro = document.createElement('h3');

	if (!id || id === "") {
		erro.innerText = "Ops! Página errada? O Id informado é inválido :/"
		document.body.appendChild(erro);
		return;
	}

	const filme = await service.umFilme(id);

	document.title += `: ${filme.titulo} (Filme)`;

	const tituloELancamento = document.createElement('h2');
	tituloELancamento.innerText = `${filme.titulo} (${filme.anoLancamento})`
	document.body.appendChild(tituloELancamento);

	appendHr();

	const sinopse = document.createElement('p');
	sinopse.innerText = filme.sinopse;
	document.body.appendChild(sinopse);

	appendHr();

	const detalhes = document.createElement('ul');

	const notaIMDB =
		createLi(detalhes).innerHTML =
		`<strong>Nota no IMDB:</strong> ${filme.notaIMDB}`;

	const diretor =
		createLi(detalhes).innerHTML =
		`<strong>Diretor:</strong> <a href="./diretor.html?id=${filme.diretor.id}">${filme.diretor.nome}</a>`;

	const atores = createLi(detalhes).innerHTML =
		`
		<strong>Atores:</strong>
		<ul>
		${filme.atores.map(atorPapel =>
			`
			<li>
				<a href="./ator.html?id=${atorPapel.ator.id}">${atorPapel.ator.nome}</a> como ${atorPapel.papel}
			</li>
			`
		).join("")
		}
		</ul>
		`

	document.body.appendChild(detalhes);
}

carregarFilme();