import React from 'react';
import { createStackNavigator } from '@react-navigation/stack';
import { NavigationContainer } from '@react-navigation/native';
import Inicio from '../Screens/Inicio';

const Stack = createStackNavigator();

export default function StackNavigator() {
  return (
    <NavigationContainer>
      <Stack.Navigator initialRouteName="Inicio">
        <Stack.Screen name="Inicio" component={Inicio} options={{ title: 'Inicio' }} />
        {/* Aquí añadiremos las otras pantallas como Destinos, Hospedajes en el futuro */}
      </Stack.Navigator>
    </NavigationContainer>
  );
}