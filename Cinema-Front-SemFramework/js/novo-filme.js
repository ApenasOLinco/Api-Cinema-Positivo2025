import * as service from './service/FilmesService.js';
let numPapeis = 0;

function adicionarPapel() {
	const papel_template = document.querySelector('#papel-template');
	const container = document.querySelector('#papeis-container');

	const papel = document.importNode(papel_template.content, true).querySelector('fieldset');

	const posicao = numPapeis;
	const id = papel.id = `papel-${posicao + 1}`;

	// Legend
	let legend = (id.charAt(0).toUpperCase()) + id.slice(1).replace('-', ' ');
	papel.querySelector('legend').innerText = legend;

	// Botão de remover, caso aplicável
	if (container.children.length > 1) {
		const btn_remover = document.createElement('button');
		btn_remover.innerText = "Remover";
		btn_remover.type = "button";

		btn_remover.addEventListener('click', (e) => {
			document.querySelector(`#${id}`).remove();
			numPapeis--;
		});

		papel.appendChild(btn_remover);
	}

	container.appendChild(papel);
	numPapeis++;
}

// É necessário pelo penos um papel no filme.
adicionarPapel();

// Botão de adicionar papel
document.querySelector('#btn-adicionar-papel').addEventListener('click', adicionarPapel);

// Enviar form
document.querySelector('#form-filme').addEventListener('submit', (e) => {
	if(!e.target.checkValidity()) {
		return;
	}
	
	e.preventDefault();

	const data = new FormData(document.querySelector('#form-filme'));

	const generos = data.get('generos')
		.replace(/(,| )+$/, '')
		.replaceAll(/(,|, ){2,}/g, ',')
		.split(/(?:, *)/);

	const filme = {
		titulo: data.get('titulo'),
		anoLancamento: data.get('anoLancamento'),
		sinopse: data.get('sinopse'),
		notaIMDB: data.get('notaIMDB'),
		generos: generos,
		diretor: {
			nome: data.get('diretor-nome'),
			dataNasc: data.get('diretor-dataNasc'),
			biografia: data.get('diretor-biografia')
		},
		papeis: []
	}

	document.querySelectorAll('#papeis-container > fieldset')
		.forEach(personagem => {
			const papel = personagem.querySelector('.papel').value;
			const ator = {
				nome: personagem.querySelector('.ator-nome').value,
				dataNasc: personagem.querySelector('.ator-dataNasc').value
			}

			filme.papeis.push({ ator: ator, papel: papel });
		});

	const resposta = service.novoFilme(filme);
	
	if(resposta.ok) {
		alert(`Filme "${filme.titulo}" adicionado com sucesso.`);
	} else {
		alert(
			`Não foi possível adicionar o filme fornecido. Tente novamente.`
		);
	}

	console.log("🚀 ~ document.querySelector ~ filme:", filme);
});
