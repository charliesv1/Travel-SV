import React from 'react';
import { View, Text, StyleSheet } from 'react-native';

export default function Hospedajes() {
  return (
    <View style={styles.container}>
      <Text style={styles.title}>Hospedajes Disponibles</Text>
      <Text>Encuentra los mejores lugares para hospedarte en El Salvador.</Text>
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