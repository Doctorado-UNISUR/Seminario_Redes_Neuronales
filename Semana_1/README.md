# Práctica de Implementación de la Red Neuronal Artificial Perceptrón

<p align="center">
  <img src="https://d2j6dbq0eux0bg.cloudfront.net/images/43093237/3601039288.png" alt="Universidad del Sur">
</p>

## Universidad del Sur

### DSIC409 - Seminario de Redes Neuronales

**Profesor:** Rodolfo Eesteban Ibarra

**Estudiante:** Juan Carlos González

---

# Perceptron

Este proyecto implementa un perceptrón simple para la clasificación binaria de pingüinos basado en características como la profundidad del pico y la longitud de la aleta. El objetivo principal es clasificar a los pingüinos en dos categorías: **Gentoo** y **no Gentoo**.

## Estructura del Proyecto

### Diagrama
```text
perceptron-penguins/
│
├── rnaperceptron/
│   ├── DataLoader.cs         # Carga datos de pingüinos desde CSV
│   ├── Penguin.cs            # Clase modelo para representar pingüinos
│   ├── Perceptron.cs         # Implementación del algoritmo de perceptrón
│   └── Program.cs            # Punto de entrada con menú interactivo
├── data/
│   └── penguins_size.csv     # Dataset con información de pingüinos
└── README.md                 # Documentación del proyecto
```

El proyecto está organizado en los siguientes archivos principales:

- **`DataLoader.cs`**: Contiene una clase utilitaria para cargar datos de pingüinos desde un archivo CSV, omitiendo filas con datos faltantes.
- **`Perceptron.cs`**: Implementa el perceptrón, incluyendo las funciones de activación, entrenamiento, clasificación, validación cruzada y cálculo de pérdida.
- **`Penguin.cs`**: Define la clase `Penguin`, que representa un pingüino con sus características relevantes.
- **`Program.cs`**: Contiene el punto de entrada principal del programa y un menú interactivo para ejecutar las funcionalidades del perceptrón.
- **`penguins_size.csv`**: Archivo de datos que contiene información sobre pingüinos, como especie, profundidad del pico, longitud de la aleta, y más.

### Funcionalidades

El programa permite realizar las siguientes acciones:

1. **Cargar datos**: Leer un archivo CSV con información de pingüinos (path: "**_data/penguins_size.csv_**").
2. **Dividir datos**: Separar los datos en conjuntos de entrenamiento (80%) y prueba (20%).
3. **Entrenar el perceptrón**: Ajustar los pesos y el sesgo del modelo utilizando los datos de entrenamiento.
4. **Probar el perceptrón**: Evaluar el modelo con los datos de prueba y mostrar los resultados.
5. **Validación cruzada**: Realizar validación cruzada k-fold para evaluar la precisión del modelo.
6. **Calcular la función de pérdida (Loss)**: Evaluar el error cuadrático medio en los datos de entrenamiento.

## Requisitos

- **.NET 8.0 SDK**: El proyecto está desarrollado en .NET 8.0.
- **Archivo de datos**: Un archivo CSV con las características de los pingüinos. Se incluye un archivo de ejemplo llamado `penguins_size.csv`.

### Ejecución

1. Clona este repositorio:
   ```bash
   git clone https://github.com/tu-usuario/perceptron-penguins.git
   cd perceptron-penguins
   ```

2. Compila el proyecto:
   ```bash
   dotnet build
   ```

3. Ejecuta el programa:
   ```bash
   dotnet run
   ```

2. Compila el proyecto:
   ```bash
   dotnet build
   ```
   
3. Ejecuta el programa:
   ```bash
   dotnet run
   ```

Las instrucciones se describen desde el menú interactivo para cargar datos, entrenar y probar el perceptrón.

### Estructura del Archivo CSV
El archivo CSV debe tener el siguiente formato:

| Column Name | Description | Example Values |
|------------|-------------|---------------|
| species | Especie del pingüino | Adelie, Gentoo |
| island | Isla donde se observó el pingüino | Torgersen, Biscoe |
| culmen_length_mm | Longitud del pico en milímetros | 39.1, 50.0 |
| culmen_depth_mm | Profundidad del pico en milímetros | 18.7, 15.3 |
| flipper_length_mm | Longitud de la aleta en milímetros | 181, 220 |
| body_mass_g | Masa corporal en gramos | 3750, 5550 |
| sex | Sexo del pingüino | MALE


Las columnas relevantes para el modelo son:

- **species**: Especie del pingüino (por ejemplo, "Gentoo").
- **culmen_depth_mm**: Profundidad del pico en milímetros.
- **flipper_length_mm**: Longitud de la aleta en milímetros.

### Ejemplo de Uso
1. Carga los datos desde el archivo **_model/penguins_size.csv_**.
2. Divide los datos en entrenamiento y prueba.
3. Entrena el perceptrón con 100 épocas y una tasa de aprendizaje de 0.01.
4. Prueba el modelo y observa los resultados de clasificación.
5. Realiza validación cruzada para evaluar la precisión promedio.

---

## Contribuciones
Se desea mejorar este proyecto, por favor puede contribuir.

---

## Licencia
Este proyecto está licenciado bajo la MIT License.

---   