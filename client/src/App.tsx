import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import React, { useEffect, useState } from 'react';
import styles from './App.module.css';
import { IMessage } from './models/message';

function App() {
  const [hubConnection, setHubConnection] = useState<HubConnection | null>(null);


  useEffect(() => {
    const newHubConnection = new HubConnectionBuilder()
      .withUrl('https://localhost:5001/chat')
      .withAutomaticReconnect()
      .build();

    setHubConnection(newHubConnection);
  }, []);

  useEffect(() => {
    if (hubConnection) {
      hubConnection.start()
        .then(result => {
          hubConnection.on('ReceiveConnected', (userId: string) => {
            console.log('you are connected to the hub as ' + userId);
          })

          hubConnection.on('ReceiveMessage', (message: IMessage) => {
            console.log('message received: ' + message.content);
          })

        })
        .catch(error => {
          console.log('hub connection error: ' + error);
        })

    }
  }, [hubConnection]);



return (
  <div className={styles.app}>

  </div>
);
}

export default App;
