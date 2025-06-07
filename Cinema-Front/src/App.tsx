import { Route, Routes } from 'react-router-dom';
import Home from './pages/Home';
import DetalhesFilme from './pages/DetalhesFilme';

function App() {
	return (
		<>
			<main className='main-content'>
				<Routes>
					<Route path='/' element={<Home />} />
					<Route path='/filme/:id' element={<DetalhesFilme />}></Route>
				</Routes>
			</main>
		</>
	)
}

export default App;