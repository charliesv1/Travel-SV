import React from 'react';
import { View, Text, StyleSheet } from 'react-native';

export default function Destinos() {
  return (
    <View style={styles.container}>
      <Text style={styles.title}>Destinos Turísticos</Text>
      <Text>Lista de los mejores destinos turísticos de El Salvador.</Text>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
  },
  title: {
    fontSize: 22,
    fontWeight: 'bold',
    marginBottom: 10,
  },
});