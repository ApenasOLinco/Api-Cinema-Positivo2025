const ENV = await fetch("/resources/env.json")
.then(resp => resp.json())

const FETCH_URL = `${ENV.api_url}/api/v1/Filmes`;