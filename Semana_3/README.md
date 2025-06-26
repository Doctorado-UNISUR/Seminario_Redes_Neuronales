# Práctica de Redes Neuronales Artificiales

<div align="center">

<img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRerieaMJrxMRIysI8dT9J_r3EJGnR_-5Mb-A&s" alt="Logo de la Institución" width="400">

---

**Universidad del Sur**  
**Doctorado en Sistemas Computacionales**  
**DSIC409 - Seminario de Redes Neuronales**  
**Docente:** Dr. Rodolfo Esteban Ibarra  
**Estudiante:** Juan Carlos González Ibarra  
**Correo Institucional:** jcgi.laboral@gmail.com  
**Fecha:** 27 de junio, 2025

</div>

---

## Índice

1. **Introducción**
2. **Antecedentes**
   - 2.1 Análisis Exploratorio de Datos
   - 2.2 Metodología en el Análisis de Datos
   - 2.3 Modelado de datos
   - 2.4 Métodos de Modelado
3. **Descripción del Tema**
4. **Metodología de Desarrollo**
5. **Data Clean**
6. **Análisis exploratorio de Datos (AED)**
7. **Resultados de AED**
8. **Modelado de Datos**
9. **Resultados de validación y prueba del modelo de red neuronal**
10. **Conclusión**
11. **Bibliografía**

---

## 1. Introducción

Las Redes Neuronales Artificiales (RNAs) son herramientas efectivas para el análisis de datos, capaces de aproximar funciones complejas y clasificar elementos a partir de múltiples variables. Han sido aplicadas en predicción de tendencias, segmentación, recomendación y clasificación de patrones de comportamiento, especialmente útiles en proyectos con grandes volúmenes de datos y relaciones no lineales.

Entre los modelos más representativos están el perceptrón multicapa (MLP), las redes de funciones de base radial (RBF) y las máquinas de vectores de soporte (SVM). El entrenamiento de estas redes suele realizarse mediante el algoritmo de backpropagation, que ajusta los parámetros internos para minimizar los errores de predicción.

---

## 2. Antecedentes

### 2.1 Análisis Exploratorio de Datos

El AED es esencial para analizar conjuntos de datos, resumir sus características principales y visualizar la estructura de los datos antes de aplicar modelos complejos.

### 2.2 Metodología en el Análisis de Datos

Incluye la definición del problema, recolección y limpieza de datos, AED, modelado, evaluación y comunicación de resultados.

### 2.3 Modelado de datos

Se desarrollan modelos predictivos o descriptivos según el objetivo, utilizando técnicas estadísticas o matemáticas.

### 2.4 Métodos de Modelado

- **No Supervisado:** Asociación, segmentación.
- **Supervisado:** Clasificación, regresión, redes neuronales, SVM, etc.

---

## 3. Descripción del Tema

**Planteamiento del problema:**  
La deserción escolar en educación superior es un reto importante. Se requiere identificar factores que influyen en la permanencia o abandono de los estudios.

**Tema de investigación:**  
Análisis de la correlación entre factores predictivos y la deserción escolar en la educación superior mediante modelos de Red Neuronal Artificial.

**Pregunta de investigación:**  
¿Cómo pueden los factores académicos, socioeconómicos y demográficos ser utilizados por un modelo de RNA para predecir el riesgo de abandono estudiantil?

**Objetivo General:**  
Analizar los factores que influyen en la deserción estudiantil para identificar patrones predictivos y diseñar estrategias de retención.

---

## 4. Metodología de Desarrollo

- Definición de la variable objetivo: Deserción (Dropout, Enrolled, Graduate).
- Selección de variables relevantes: Estado civil, modalidad de ingreso, calificaciones previas, escolaridad de los padres, deudas, beca, edad de ingreso, carga académica y rendimiento.
- Limpieza y preprocesamiento de datos.
- Análisis exploratorio de datos (AED).
- Construcción y entrenamiento de un modelo de RNA multicapa (MLP) con backpropagation.
- Evaluación del modelo mediante accuracy, precisión, recall, F1-score y matriz de confusión.

---

## 5. Data Clean

- Descripción y limpieza de los datos obtenidos del UCI Machine Learning Repository.
- Imputación de valores faltantes, conversión de tipos de datos y revisión de valores atípicos.
- Selección de variables relevantes para el análisis de deserción escolar.

---

## 6. Análisis exploratorio de Datos (AED)

- Análisis univariado y bivariado de variables académicas, demográficas y socioeconómicas.
- Identificación de factores asociados a la deserción: estado civil, género, modalidad de ingreso, calificaciones previas, escolaridad de los padres, deudas, beca, edad de ingreso, carga académica y rendimiento.

---

## 7. Resultados de AED

- El conjunto de datos está desbalanceado: Graduate (49.9%), Dropout (32.1%), Enrolled (17.9%).
- Factores como deudas, bajo rendimiento académico, baja escolaridad de los padres y mayor edad de ingreso están asociados a mayor riesgo de deserción.

---

## 8. Modelado de Datos

- Se implementa una RNA multicapa con 3 capas ocultas y activación Tanh.
- Entrenamiento mediante backpropagation y descenso de gradiente estocástico (SGD).
- División de datos en entrenamiento, validación y prueba.

---

## 9. Resultados de validación y prueba del modelo de red neuronal

**Desempeño general (accuracy):**
- Validación: 73%
- Prueba: 73%

**Deserción (Dropout):**
- Recall: 0.76 (validación), 0.77 (prueba)
- Precisión: 0.70 (ambos)
- El modelo predice un número de deserciones similar al real.

**Graduados (Graduate):**
- Recall: 0.97 (validación), 0.96 (prueba)
- Precisión: 0.75 (ambos)

**Inscritos (Enrolled):**
- Recall: 0.02 (validación), 0.01 (prueba)
- Precisión: 1.00 (validación), 0.33 (prueba)

**Macro avg:**  
Recall y f1-score bajos (~0.53), indicando que el modelo no es equilibrado entre clases.

---

## 10. Conclusión

El modelo de RNA desarrollado permite identificar patrones complejos asociados a la deserción escolar, logrando una precisión del 73%. La metodología abarca desde la limpieza y análisis exploratorio de datos hasta la construcción, entrenamiento y evaluación del modelo. Se valida la utilidad de las RNAs para tareas de clasificación en educación superior.

---

## 11. Bibliografía

- Alejo, R., Monroy, J., Ambriz, J. C., & Pacheco-Sánchez, J. H. (2017). *An improved dynamic sampling back-propagation algorithm based on mean square error to face the multiclass imbalance problem*. Neural Computing and Applications, 28(10), 2843–2857.
- Andreu, M. E., Pareja, R. M., & Gelabert, A. S. (2020). *Aspiraciones ocupacionales y expectativas y elecciones educativas de los jóvenes en un contexto de crisis*. Revista Española de Sociología, 29(3), 27–46.
- Benítez, J. M., Castro, J. L., & Requena, I. (1997). *Are artificial neural networks black boxes?* IEEE Transactions on Neural Networks, 8(5), 1156–1164.
- Caicedo Bravo, E., & López Sotelo, J. (2009). *Una aproximación práctica a las redes neuronales artificiales*. Programa Editorial Universidad del Valle.
- Duda, R., Hart, P., & Stork, D. (2001). *Pattern classification and scene analysis*. Wiley.
- Eckert, K. B., & Suénaga, R. (2015). *Análisis de deserción permanencia de estudiantes universitarios utilizando técnica de clasificación en minería de datos*. Formación Universitaria, 8(5), 3–12.
- Estrada, M. (2018). *Abandono escolar en la educación media superior de México, políticas, actores y análisis de casos* (1ra ed.).
- Fernández, A., García, S., & Herrera, F. (2018). *SMOTE for learning from imbalanced data: Progress and challenges, marking the 15-year anniversary*. Journal of Artificial Intelligence Research, 61(1), 863–905.
- Flóres López, R., & Fernandez, J. (2008). *Las redes neuronales artificiales*. Gesbiblio S.L.
- Graupe, D. (2013). *Principios de redes neuronales artificiales* (Vol. 7). World Scientific.
- Heredia, D., Amaya, Y., & Barrientos, E. (2015). *Student dropout predictive model using data mining techniques*. IEEE Latin America Transactions, 9(13), 3127–3134.
- Incio, F., Capuñay Sanchez, D., Estela Urbina, R., Delgado Soto, J., & Vergara Medrano, S. (2021). *Diseño e implementación de una red neuronal artificial para predecir el rendimiento académico en estudiantes de Ingeniería Civil de la UNIFSLB*. Veritas et Scientia, 11.
- Zambrano Matamala, C., Rojas Díaz, D., Carvajal Cuello, K., & Acuña Leiva, G. (2011). *Análisis de rendimiento académico estudiantil usando data warehouse y redes neuronales*. Ingeniare. Revista Chilena de Ingeniería, 14.











