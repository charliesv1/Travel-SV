import React from "react";
import { View, Text, Button, StyleSheet } from 'react-native';

export default function Inicio({ navigation }) {
  return (
    <View style={styles.container}>
      <Text style={styles.title}>¡Bienvenidos a TravelSV!</Text>
      <Text style={styles.description}>
        Explora los destinos turísticos más asombrosos de El Salvador, desde playas paradisíacas hasta volcanes majestuosos, ademas descubre dónde hospedarte y disfruta de la riqueza cultural y natural que ofrece este hermoso país.
      </Text>
      {/* Menú de navegación hacia futuras pantallas */}
      <Button
        title="Ver Destinos"
        onPress={() => navigation.navigate('Destinos')} // Pantalla futura
      />
      <Button
        title="Ver Hospedajes"
        onPress={() => navigation.navigate('Hospedajes')} // Pantalla futura
        style={styles.button}
      />
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    padding: 20,
    backgroundColor: '#f5f5f5'
  },
  title: {
    fontSize: 24,
    fontWeight: 'bold',
    marginBottom: 20,
    textAlign: 'center'
  },
  description: {
    fontSize: 16,
    textAlign: 'center',
    marginBottom: 40,
    color: '#555'
  },
  button: {
    marginVertical: 10
  }
});