# Práctica: Reconocimiento de Letras con MADALINE

## Descripción

Este proyecto implementa una red neuronal MADALINE para el reconocimiento y clasificación de letras del alfabeto (A-Z) utilizando el dataset "Letter Recognition" de UCI. El flujo abarca desde la descarga y preprocesamiento de datos, hasta el entrenamiento, evaluación y análisis de resultados del modelo.

---

## Estructura del Proyecto

- `MADALINE_Recognition.ipynb`: Notebook como reporte con el código y análisis.
- `letter-recognition.data`: Dataset de entrenamiento y prueba.
- `model/madaline_letter_classifier.pkl`: Este es el modelo que se entreno y se guardo para utilizar en la validación o predicción.
- `README.md`: Este archivo, con instrucciones y explicaciones.

---

## Requisitos

- Python 3.8+
- Bibliotecas:
  - numpy
  - pandas
  - matplotlib
  - seaborn
  - scikit-learn
  - tqdm
  - jupyter

Instala las dependencias con:

```bash
pip install numpy pandas matplotlib seaborn scikit-learn tqdm jupyter
```

---

## Instrucciones de Uso

1. **Clona el repositorio o descarga los archivos.**

2. **Abre el notebook:**
   ```bash
   jupyter notebook MADALINE_Recognition.ipynb
   ```

3. **Ejecuta todas las celdas** para reproducir el flujo completo:
   - Descarga y preprocesamiento de datos.
   - Implementación y entrenamiento del modelo MADALINE.
   - Evaluación y visualización de resultados.
   - Análisis detallado de predicciones.
   - Guardado del modelo entrenado.

---

## Explicación del Flujo

### 1. **Carga y Preprocesamiento de Datos**
- Se utiliza el dataset "Letter Recognition" de UCI.
- Las letras se codifican numéricamente (A=0, ..., Z=25).
- Los datos se normalizan a un rango [-1, 1].
- Se dividen en conjuntos de entrenamiento y prueba (80/20).

### 2. **Implementación de MADALINE**
- Se implementa una clase `MadalineClassifier` que sigue la lógica tradicional de MADALINE:
  - Una capa oculta de neuronas tipo ADALINE.
  - Regla MRI: solo se actualiza la neurona más "confundida" en cada iteración.
  - Clasificación multiclase usando "uno contra todos".

### 3. **Entrenamiento**
- El modelo se entrena por clase.
- Se monitoriza el error cuadrático por época.

### 4. **Evaluación**
- Se calcula la precisión global y por clase.
- Se visualiza la matriz de confusión y la precisión por letra.

### 5. **Análisis de Predicciones**
- Se analizan los scores de predicción para cada letra.
- Se identifican errores y se visualizan los resultados.

### 6. **Guardado del Modelo**
- El modelo entrenado, el scaler y el encoder se guardan en un archivo `.pkl` para uso futuro.

---

## Notas sobre MADALINE

- Esta implementación sigue la lógica clásica de MADALINE (regla MRI), **no utiliza retropropagación ni minimiza el error cuadrático global** como en redes modernas.
- Si deseas una versión moderna, deberías modificar el entrenamiento para actualizar todos los pesos usando el gradiente del error.

---

## Créditos

- Dataset: [UCI Machine Learning Repository - Letter Recognition Data Set](https://archive.ics.uci.edu/ml/datasets/letter+recognition)
- Implementación y análisis: [Juan Carlos González]

---

## Licencia

Este proyecto es solo para fines educativos.