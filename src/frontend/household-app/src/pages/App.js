import React, { useState, useEffect } from 'react';

export default function App() {
	const [isLoading, setIsLoading] = useState(false);
	const [isError, setIsError] = useState(false);
	const [errorMessage, setErrorMessage] = useState();
	const [weatherForecasts, setWeatherForecasts] = useState();

	useEffect(() => {
		const fetchData = async () => {
			setIsLoading(true)

			try {
				const response = await fetch('http://localhost:5260/WeatherForecast');
				const data = await response.json();
				setWeatherForecasts(data);
			} catch (error) {
				setIsError(true)
				setErrorMessage(error.message)
			} finally {
				setIsLoading(false)
			}
		};

		fetchData();
	}, [])

	if (isError) {
		return <div>Error occured : {errorMessage}</div>
	}

	if (isLoading) {
		return <div>Loading...</div>
	}

	return (
		<div>
		<h1>Forecasts:</h1>
		<ul>
				{weatherForecasts.map((forecast) => {
					return <li key={forecast}>{forecast.summary}</li>;
					})
				}
			</ul>
		</div>
		);
}
