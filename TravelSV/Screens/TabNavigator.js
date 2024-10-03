import React from 'react';
import { useWindowDimensions } from 'react-native'; //Hook para detectar el tamaño de la pantalla
import { createMaterialTopTabNavigator } from '@react-navigation/material-top-tabs';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs'; // Para tabs en la parte inferior
import Inicio from '../Screens/Inicio';
import Destinos from '../Screens/Destinos';
import Hospedajes from '../Screens/Hospedajes';

const TopTab = createMaterialTopTabNavigator(); // Tabs superiores (para web)
const BottomTab = createBottomTabNavigator(); // Tabs inferiores (para móvil)

export default function TabNavigator() {
  const { width } = useWindowDimensions(); // Detecta el ancho de la pantalla

  // Si el ancho es mayor a 768px (típico de pantallas grandes como la web), usamos tabs superiores
  if (width > 768) {
    return (
      <TopTab.Navigator
        initialRouteName="Inicio"
        screenOptions={{
          tabBarActiveTintColor: '#000',
          tabBarLabelStyle: { fontSize: 12 },
          tabBarStyle: { backgroundColor: '#fff' },
        }}
      >
        <TopTab.Screen name="Inicio" component={Inicio} />
        <TopTab.Screen name="Destinos" component={Destinos} />
        <TopTab.Screen name="Hospedajes" component={Hospedajes} />
      </TopTab.Navigator>
    );
  } else {
    // Para móviles o pantallas pequeñas usamos tabs inferiores
    return (
      <BottomTab.Navigator
        initialRouteName="Inicio"
        screenOptions={{
          tabBarActiveTintColor: '#000',
          tabBarLabelStyle: { fontSize: 12 },
          tabBarStyle: { backgroundColor: '#fff' },
        }}
      >
        <BottomTab.Screen name="Inicio" component={Inicio} />
        <BottomTab.Screen name="Destinos" component={Destinos} />
        <BottomTab.Screen name="Hospedajes" component={Hospedajes} />
      </BottomTab.Navigator>
    );
  }
}