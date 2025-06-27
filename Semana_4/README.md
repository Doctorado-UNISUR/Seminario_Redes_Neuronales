# Descripción del Proyecto

Este proyecto implementa una Red Neuronal Artificial (DNN) para la detección de Trastorno del Espectro Autista (TEA) en niños, utilizando el conjunto de datos "Autistic Spectrum Disorder Screening Data for Children" de la UCI Machine Learning Repository.

## Objetivo

Desarrollar un modelo de clasificación capaz de predecir la presencia de TEA a partir de respuestas a un cuestionario y variables demográficas, empleando técnicas de preprocesamiento, análisis exploratorio y una arquitectura DNN personalizada.

## Flujo de Trabajo

1. **Carga y limpieza de datos:**  
    - Descarga automática del dataset.
    - Limpieza y transformación de variables (binarias, categóricas y numéricas).

2. **Análisis exploratorio:**  
    - Visualización de correlaciones y distribución de clases.
    - Selección y normalización de características relevantes.

3. **Modelado:**  
    - Implementación desde cero de una DNN multicapa en NumPy.
    - Entrenamiento, validación y ajuste de hiperparámetros.
    - Evaluación con métricas de clasificación (accuracy, recall, precision, F1, ROC AUC).

4. **Interpretabilidad:**  
    - Análisis de importancia de variables.
    - Visualización de curvas ROC.

5. **Despliegue:**  
    - Guardado del modelo, scaler y encoder para integración en aplicaciones (ej. Streamlit).

## Requisitos

- Python 3.8+
- pandas, numpy, matplotlib, seaborn, scikit-learn, ucimlrepo

## Uso

1. Clona el repositorio.
2. Instala los requisitos.
3. Ejecuta el notebook paso a paso para reproducir el flujo completo.
4. El modelo entrenado se guarda en `models/dnn_streamlit.pkl` listo para producción.

## Implementación de Sistema de Detección Temprana de Autismo con Streamlit

Este proyecto implementa una herramienta web para la detección temprana de signos de autismo en niños, utilizando un modelo de red neuronal profunda (DNN) y Streamlit como interfaz de usuario.

<p align="center">
  <img alt="Imagen de muestra" src="https://d2j6dbq0eux0bg.cloudfront.net/images/43093237/3601039288.png" width="200">
</p>

## Características principales

- **Cuestionario de detección**: Basado en M-CHAT (Modified Checklist for Autism in Toddlers)
- **Modelo IA**: Red neuronal profunda entrenada para detectar patrones asociados con TEA
- **Resultados intuitivos**: Presentación clara y recomendaciones basadas en las respuestas
- **Interfaz amigable**: Diseño intuitivo y responsivo para facilitar la experiencia de usuario

## Requisitos

Para ejecutar la aplicación, necesitarás instalar las  dependencias del archivo `requirements.txt`.
- streamlit

## Estructura de directorios
```text
📁 project-root/
├── 📄 app.py                  # 🚀 Aplicación principal (Streamlit)
├── 📁 models/
│   └── 📦 dnn_streamlit.pkl   # 🤖 Modelo DNN entrenado
├── 📁 assets/
│   └── 🖼️ logo.png            # 🔖 Logo de la aplicación
├── 📓 DNN.ipynb               # 🔬 Notebook de entrenamiento
├── 📝 requirements.txt        # 📦 Dependencias (pip)
└── 📘 README.md               # 📚 Documentación             
└── README.md               # Documentación del proyecto
```

## Cómo ejecutar la aplicación

- Asegúrate de tener todas las dependencias instaladas:
```bash
pip install -r requirements.txt
```
- Ejecuta la aplicación con Streamlit:
```bash
streamlit run app.py
```
- Se abrirá automáticamente una ventana del navegador con la aplicación en funcionamiento.

## Funcionamiento de la aplicación

### 🖥️ Interfaz de usuario

- **Formulario de preguntas**  
  Dividido en dos columnas para facilitar la navegación y mejorar la experiencia de usuario.

- **Panel lateral informativo**  
  Contiene:
  - Instrucciones claras para completar el cuestionario
  - Advertencias sobre el uso adecuado de la herramienta
  - Información sobre la metodología M-CHAT

- **Botón de análisis**  
  Diseñado prominentemente para enviar las respuestas y generar el reporte.

### 🔄 Procesamiento de datos

1. **Conversión a valores numéricos**  
   Cada respuesta del usuario se transforma a un formato que el modelo puede interpretar:
    - "Sí" → 1
    - "No" → 0
    - "Femenino" → 0
    - "Masculino" → 1


2. **Estandarización de datos**  
Se aplica `StandardScaler` para normalizar los valores:
```python
X_scaled = scaler.transform(X)
```

3. **Procesamiento con red neuronal**  
- Flujo de propagación hacia adelante:
- Entrada → Capa Oculta (ReLU) → Capa Oculta (ReLU) → Salida (Softmax)

3. **Presentación de resultados**

| Componente           | Descripción                                                                 |
|----------------------|-----------------------------------------------------------------------------|
| **Indicación de riesgo** | Visualización clara con código de colores:<br>- 🔴 Rojo: Riesgo detectado<br>- 🟢 Verde: Sin riesgo detectado |
| **Recomendaciones**  | Sugerencias específicas basadas en el nivel de riesgo detectado             |
| **Nota legal**       | Aclaración sobre el carácter informativo (no diagnóstico) de la herramienta |

> **Nota**: Los resultados deben interpretarse como una guía preliminar, no como un diagnóstico médico definitivo. Se recomienda siempre consultar con un especialista.

## Referencias

- [UCI ASD Screening Data for Children](https://archive.ics.uci.edu/dataset/419/autistic+spectrum+disorder+screening+data+for+children)
- Documentación y referencias adicionales en el notebook.

---