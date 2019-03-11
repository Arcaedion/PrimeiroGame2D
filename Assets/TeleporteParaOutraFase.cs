using Cinemachine;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

namespace Gamekit2D
{
    [RequireComponent(typeof(Collider2D))]
    public class TeleporteParaOutraFase : MonoBehaviour
    {

        [Tooltip("Objeto de transição, por exemplo, o jogador.")]
        public GameObject objetoDeTransicao;
        [Tooltip("O nome da cena que vai ser carregada.")]
        public string nomeDaCena;
        [Tooltip("A letra da tag usada na cena descrita acima(uma letra, de A a G).")]
        public string letraDaTag;
        [Tooltip("The player will lose control when the transition happens but should the axis and button values reset to the default when control is lost.")]
        public bool resetInputValuesOnTransition = true;
        

        void OnTriggerEnter2D(Collider2D colisao)
        {
            if (colisao.gameObject == objetoDeTransicao)
            {

                if (ScreenFader.IsFading || SceneController.Transitioning)
                    return;
                TransitionInternal();
            }
        }


        protected void TransitionInternal()
        {
            var transitionPoint = new TransitionPoint();
            transitionPoint.newSceneName = nomeDaCena;
            transitionPoint.resetInputValuesOnTransition = resetInputValuesOnTransition;
            transitionPoint.transitionDestinationTag = GetDestinationTag(letraDaTag);
            transitionPoint.transitionType = TransitionPoint.TransitionType.DifferentZone;
            SceneController.TransitionToScene(transitionPoint);
        }

        private SceneTransitionDestination.DestinationTag GetDestinationTag(string letra)
        {
            switch (letra)
            {
                case "A":
                    return SceneTransitionDestination.DestinationTag.A;
                case "B":
                    return SceneTransitionDestination.DestinationTag.B;
                case "C":
                    return SceneTransitionDestination.DestinationTag.C;
                case "D":
                    return SceneTransitionDestination.DestinationTag.D;
                case "E":
                    return SceneTransitionDestination.DestinationTag.E;
                case "F":
                    return SceneTransitionDestination.DestinationTag.F;
                case "G":
                    return SceneTransitionDestination.DestinationTag.G;
                default:
                    throw new System.Exception("Letra de tag destino inválida. Apenas A,B,C,D,E,F e G são suportados.");
            }
        }
    }
}