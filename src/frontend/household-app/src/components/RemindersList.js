import Reminder from "./Reminder";

export default function RemindersListComponent({ reminders, onDeleteReminder }){
	function onDelete(reminder) {
		onDeleteReminder(reminder);
	}

	return (
		<>
			<h1 className="text-xl font-bold mb-4">Reminders:</h1>
			<ul className="list-disc pl-6">
				{reminders.map((reminder, index) => (
					<li key={index} className="mb-2">
						<Reminder reminder={reminder} onDelete={onDelete} />
					</li>
				))}
			</ul>
		</>
	);
}
