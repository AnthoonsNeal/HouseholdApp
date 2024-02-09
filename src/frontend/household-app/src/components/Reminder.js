export default function Reminder({ reminder, onDelete }) {
	function onClick(){
		onDelete(reminder);
	}

	return(
		<div className="flex justify-between">
			{reminder}
			<button
				className="bg-red-500 hover:bg-red-700 text-white font-bold py-2 px-4 rounded-r"
				onClick={onClick}
			>
				Verwijder
			</button>
		</div>
	)
}
