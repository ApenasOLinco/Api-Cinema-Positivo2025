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
document.querySelector('#form-filme').addEventListener('submit', async (e) => {
	if(!e.target.checkValidity()) {
		return;
	}
	
	e.preventDefault();

	const dados = new FormData(document.querySelector('#form-filme'));

	const generos = dados.get('generos')
		.replace(/(,| )+$/, '')
		.replaceAll(/(,|, ){2,}/g, ',')
		.split(/(?:, *)/);

	const formatarData = (dataString) => {
		const data = new Date(dataString);

		const dia = String(data.getUTCDate()).padStart(2, '0');
		const mes = String(data.getMonth() + 1).padStart(2, '0');
		const ano = String(data.getFullYear());

		const formatada = `${dia}-${mes}-${ano}`;
		return formatada;
	}

	const filme = {
		titulo: dados.get('titulo'),
		anoLancamento: parseInt(dados.get('anoLancamento')),
		sinopse: dados.get('sinopse'),
		notaIMDB: parseFloat(dados.get('notaIMDB')),
		preco: parseFloat(dados.get('preco')),
		generos: generos,
		diretor: {
			nome: dados.get('diretor-nome'),
			dataNasc: formatarData(dados.get('diretor-dataNasc')),
			biografia: dados.get('diretor-biografia')
		},
		papeis: []
	}

	document.querySelectorAll('#papeis-container > fieldset')
		.forEach(personagem => {
			const papel = personagem.querySelector('.papel').value;
			const ator = {
				nome: personagem.querySelector('.ator-nome').value,
				dataNasc: formatarData(personagem.querySelector('.ator-dataNasc').value)
			}

			filme.papeis.push({ ator: ator, papel: papel });
		});

	const foiCriado = await service.novoFilme(filme);
	
	if(foiCriado) {
		alert(`Filme "${filme.titulo}" adicionado com sucesso.`);
	} else {
		alert(
			`Não foi possível adicionar o filme fornecido. Tente novamente.`
		);
	}
});
