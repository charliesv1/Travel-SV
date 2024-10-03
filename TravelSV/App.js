import React from 'react';
import { NavigationContainer } from '@react-navigation/native'; // Importa NavigationContainer
import TabNavigator from '../TravelSV/Screens/TabNavigator'; // Importa el TabNavigator

export default function App() {
  return (
    <NavigationContainer>
      <TabNavigator />
    </NavigationContainer>
  );
}