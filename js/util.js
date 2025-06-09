export function appendHr() {
	document.body.innerHTML += '<hr/>';
}

export function createLi(ul) {
	const li = document.createElement('li');
	ul.appendChild(li);

	return li;
}