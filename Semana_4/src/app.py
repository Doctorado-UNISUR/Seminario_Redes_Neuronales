# Importaciones de bibliotecas necesarias

import streamlit as st
import numpy as np
import pandas as pd
import pickle
from PIL import Image
import base64

# Configuración de la página de Streamlit
# Define el título, ícono, layout y opciones del menú
st.set_page_config(
    page_title="Detección Temprana de Autismo",
    page_icon="https://d1yjjnpx0p53s8.cloudfront.net/styles/logo-original-577x577/s3/112014/logo_us.png",
    layout="wide",
    initial_sidebar_state="expanded",
    menu_items={
        "Get Help": "https://www.autismspeaks.org",
        "Report a bug": "https://github.com/tu_repositorio/issues",
        "About": """
        ## Sistema de Detección Temprana de Autismo
        Herramienta basada en inteligencia artificial para ayudar en la identificación temprana
        de señales de autismo en niños.
        """
    }
)

# Función para convertir imágenes a base64
def img_to_base64(image_path):
    with open(image_path, "rb") as img_file:
        return base64.b64encode(img_file.read()).decode()

# Cargar recursos visuales
def load_resources():
    try:
        logo = img_to_base64("img/logo.png") if st.secrets.get("HAS_LOGO", False) else None
        return {"logo": logo}
    except:
        return {"logo": None}

# Función para cargar estilos CSS
# Intenta cargar desde archivo externo o usa CSS incorporado

def local_css():
    try:
        with open("css/styles.css") as f:
            st.markdown(f"<style>{f.read()}</style>", unsafe_allow_html=True)
    except:
        # Fallback CSS si no se encuentra el archivo
        st.markdown(""" """, unsafe_allow_html=True)

# Mostrar información en el sidebar
def show_sidebar_info():
    st.sidebar.title("Acerca de esta herramienta")
    st.sidebar.markdown("""
    Este cuestionario está diseñado para ayudar en la **detección temprana** de señales 
    de autismo en niños. Basado en el **M-CHAT** (Modified Checklist for Autism in Toddlers), 
    utiliza inteligencia artificial para analizar las respuestas.
    """)
    
    st.sidebar.markdown("---")
    st.sidebar.markdown("### Instrucciones:")
    st.sidebar.markdown("""
    1. Responda todas las preguntas con sinceridad
    2. Considere el comportamiento típico de su hijo/a
    3. Si no está seguro, elija la opción que más se acerque
    """)
    
    st.sidebar.markdown("---")
    st.sidebar.markdown("### Importante:")
    st.sidebar.markdown("""
    ⚠️ Este no es un diagnóstico médico.  
    Los resultados deben ser interpretados por un profesional calificado.
    """)

# Función para mostrar resultados
def mostrar_resultado(pred):
    st.title("Resultado de la Predicción")
    st.markdown("---")
    
    if pred == 1:
        st.markdown("""
        <div class='result-box risk'>
            <h3>Resultado: Riesgo de Autismo detectado</h3>
            <p>Basado en las respuestas proporcionadas, se ha identificado un posible riesgo de autismo.</p>
            <p><strong>Recomendación:</strong> Consulte con un especialista en desarrollo infantil para una evaluación más completa.</p>
        </div>
        """, unsafe_allow_html=True)
    else:
        st.markdown("""
        <div class='result-box no-risk'>
            <h3>Resultado: Sin riesgo de Autismo detectado</h3>
            <p>Basado en las respuestas proporcionadas, no se han identificado señales significativas de autismo.</p>
            <p><strong>Recomendación:</strong> Continúe monitoreando el desarrollo de su hijo/a y consulte a un profesional si observa algún cambio.</p>
        </div>
        """, unsafe_allow_html=True)

    if st.button("Volver a realizar las preguntas"):
        st.experimental_rerun()
    
    # Nota importante en negro
    st.markdown("""
    <div class='note-text'>
        <strong>Nota importante:</strong><br><br>
        Este cuestionario es solo una herramienta de detección inicial y no constituye un diagnóstico médico. 
        Un diagnóstico formal de autismo solo puede ser realizado por un profesional de la salud calificado 
        mediante una evaluación exhaustiva.<br><br>
        Si tiene dudas o preocupaciones sobre el desarrollo de su hijo/a, le recomendamos consultar con un 
        pediatra o especialista en desarrollo infantil.
    </div>
    """, unsafe_allow_html=True)

# Cargar el modelo
@st.cache_resource
def load_model():
    with open('models/dnn_streamlit.pkl', 'rb') as f:
        data = pickle.load(f)
        return data

# Página principal
def main():
    # Cargar recursos y estilos
    resources = load_resources()
    local_css()
    
    # Mostrar logo si está disponible
    if resources["logo"]:
        st.image(f"data:image/png;base64,{resources['logo']}", width=200)
    
    # Título principal
    st.markdown("<h1 class='header'>Detección Temprana de Autismo</h1>", unsafe_allow_html=True)
    st.markdown("Complete el siguiente cuestionario sobre el comportamiento de su hijo/a:")
    
    # Mostrar información en el sidebar
    show_sidebar_info()
    
    # Cargar modelo y datos
    data = load_model()
    dnn = data['dnn']
    scaler = data['scaler']
    encoder = data['encoder']
    feature_names = data['feature_names']
    
    # Diccionario de preguntas
    # Cada una representa característica y el valor es la pregunta mostrada al usuario

    questions = {
        'a1': '¿Su hijo/a a menudo no señala para mostrar interés (por ejemplo, no señala un avión que pasa)?',
        'a2': '¿Su hijo/a a menudo no mira hacia donde otros están mirando?',
        'a3': '¿Su hijo/a a menudo no disfruta de juegos de simulación (por ejemplo, jugar a la casita)?',
        'a4': '¿Su hijo/a a menudo evita el contacto visual?',
        'a5': '¿Su hijo/a a menudo no responde cuando se le llama por su nombre?',
        'a6': '¿Su hijo/a a menudo no sonríe en respuesta a su sonrisa?',
        'a7': '¿Su hijo/a a menudo se molesta por pequeños cambios en la rutina?',
        'a8': '¿Su hijo/a a menudo hace movimientos repetitivos (por ejemplo, aleteo de manos)?',
        'a9': '¿Su hijo/a a menudo se interesa excesivamente por ciertos objetos?',
        'a10': '¿Su hijo/a a menudo parece insensible al dolor?',
        'gender': 'Género del niño/a',
        'jaundice': '¿Tuvo ictericia al nacer?',
        'autism': '¿Algún familiar directo ha sido diagnosticado con autismo?'
    }
    
    # Opciones para las preguntas
    gender_options = {'Femenino': 0, 'Masculino': 1}
    yesno_options = {'Sí': 1, 'No': 0}
    
    # Formulario de entrada
    with st.form("autism_form"):
        user_input = []
        
        # Organizar preguntas en dos columnas para mejor presentación
        col1, col2 = st.columns(2)
        
        for i, feat in enumerate(feature_names):
            # Alternar entre columnas para distribuir las preguntas
            current_col = col1 if i % 2 == 0 else col2
            
            with current_col:
                st.markdown(f"<p class='question'>{questions[feat]}</p>", unsafe_allow_html=True)
                
                if feat == 'gender':
                    val = st.selectbox("", list(gender_options.keys()), label_visibility="collapsed", key=feat)
                    user_input.append(gender_options[val])
                else:
                    val = st.selectbox("", list(yesno_options.keys()), label_visibility="collapsed", key=feat)
                    user_input.append(yesno_options[val])
        
        # Botón de envío centrado
        st.markdown("<div style='text-align: center; margin-top: 2rem;'>", unsafe_allow_html=True)
        submitted = st.form_submit_button("ANALIZAR RESPUESTAS", type="primary")
        st.markdown("</div>", unsafe_allow_html=True)
    
    # Procesar resultados
    if submitted:
        with st.spinner('Analizando respuestas...'):
            # Convertir a DataFrame con nombres de características
            X = pd.DataFrame([user_input], columns=feature_names)
            X_scaled = scaler.transform(X)
            X_scaled = X_scaled.T  # La red espera (features, samples)
            
            # Forward propagation
            def relu(z):
                return np.maximum(0, z)
            
            def softmax(z):
                exp_z = np.exp(z - np.max(z, axis=0, keepdims=True))
                return exp_z / np.sum(exp_z, axis=0, keepdims=True)
            
            def forward_propagation(X, params):
                W1, b1 = params["W1"], params["b1"]
                W2, b2 = params["W2"], params["b2"]
                W3, b3 = params["W3"], params["b3"]
                Z1 = W1 @ X + b1
                A1 = relu(Z1)
                Z2 = W2 @ A1 + b2
                A2 = relu(Z2)
                Z3 = W3 @ A2 + b3
                A3 = softmax(Z3)
                return A3
            
            y_hat = forward_propagation(X_scaled, dnn)
            pred = np.argmax(y_hat, axis=0)[0]
            
            # Mostrar resultados
            mostrar_resultado(pred)

if __name__ == "__main__":
    main()