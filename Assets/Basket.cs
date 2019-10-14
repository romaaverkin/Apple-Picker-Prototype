using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGt;

    // Start is called before the first frame update
    void Start()
    {
        // Получить ссылку на игровой объект ScoreCounter
        GameObject scoreGo = GameObject.Find("ScoreCounter");
        // Получить компонент Text этого игрового объекта
        scoreGt = scoreGo.GetComponent<Text>();
        // Установить начальное число очков равным 0
        scoreGt.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        // Получить текущие координаты указателя мыши на экране из Input
        Vector3 mousePos2D = Input.mousePosition;

        // Координата Z камеры определяет, как далеко в трехмерном пространстве
        // находится указатель мыши
        mousePos2D.z = -Camera.main.transform.position.z;

        // Преобразовать точку на двумерной плоскости экрана в трехмерные
        // координаты игры
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // Переместить корзину вдоль оси X в координату X указателя мыши
        Vector3 pos = transform.position;
        pos.x = mousePos3D.x;
        transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Отыскать яблоко, попавшее в эту корзину
        GameObject collidedWidth = collision.gameObject;
        if (collidedWidth.tag == "Apple")
        {
            Destroy(collidedWidth);

            // Преобразовать текст в scoreGT в целое число
            int score = int.Parse(scoreGt.text);
            // Добавить очки за пойманное яблоко
            score += 700;
            // Преобразовать число очков обратно в строку и вывести ее на экран
            scoreGt.text = score.ToString();

            // Запомнить высшее достижение
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }
}
