import { useState } from "react";
import axios from "axios";

export default function AddReminderComponent({ onReminderAdded }) {
	const [reminder, SetReminder] = useState('');

	function onClick() {
		const data = JSON.stringify({ reminder })
		axios.post('http://localhost:5260/Reminders/SetReminder', data, {
				headers: {
					'Content-Type': 'application/json'
				}
			})
		.then(onReminderAdded(reminder))
		.finally(SetReminder(''))
	}

	return (
		<div className="flex justify-between">
			<input
				className="border border-gray-300 rounded-l py-2 px-4 focus:outline-none focus:border-blue-500"
				type="text"
				value={reminder}
				onChange={(e) => SetReminder(e.target.value)}
				placeholder="Voer tekst in..."
			/>
			<button
				className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded-r"
				onClick={onClick}
			>
				Voeg toe
			</button>
		</div>
	)
}
