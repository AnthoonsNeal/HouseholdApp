import { useEffect, useState } from 'react';
import RemindersListComponent from '@/components/RemindersList';
import AddReminderComponent from '@/components/AddReminder';

export default function App() {
	const [isLoading, setIsLoading] = useState(false);
	const [isError, setIsError] = useState(false);
	const [errorMessage, setErrorMessage] = useState();
	const [reminders, setReminders] = useState([]);

	function onReminderAdded(reminder) {
		const newReminders = [...reminders, reminder]
		setReminders(newReminders);
	}

	useEffect(() => {
		const fetchData = async () => {
			setIsLoading(true)

			try {
				const response = await fetch('http://localhost:5260/Reminders/GetReminders');
				const data = await response.json();
				setReminders(data);
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
		<>
			<RemindersListComponent reminders={reminders}/>
			<AddReminderComponent onReminderAdded={onReminderAdded}/>
		</>
  )
}
