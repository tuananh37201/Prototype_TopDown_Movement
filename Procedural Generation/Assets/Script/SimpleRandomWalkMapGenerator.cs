using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SimpleRandomWalkMapGenerator : AbstractMapGenerator
{
    [SerializeField]
    private SimpleRandomWalk_SO randomWalkParameters;


    protected override void RunProceduralGeneration(){
        HashSet<Vector2Int> floorPositions = RunRandomWalk();
        tilemapVisualizer.Clear();
        tilemapVisualizer.PaintFLoorTile(floorPositions);
        EdgeGenerator.CreateEdge(floorPositions, tilemapVisualizer);
    }

    protected HashSet<Vector2Int> RunRandomWalk(){
        var currentPosition = startPosition;
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();

        /* 
            for (int i = 0; i < randomWalkParameters.interations; i++): 
            Đây là vòng lặp for được sử dụng để thực hiện một số lần lặp nhất định,
            được xác định bởi giá trị randomWalkParameters.interations. 
            Mỗi lần lặp sẽ tạo ra một đường đi ngẫu nhiên trên bản đồ.

            var path = ProceduralGenerationAlgorithms.SimpleRandomWalk(currentPosition, randomWalkParameters.walkLength): 
            Trong mỗi lần lặp, hàm ProceduralGenerationAlgorithms.SimpleRandomWalk được gọi để tạo ra một đường đi ngẫu nhiên. 
            Hàm này nhận đầu vào là vị trí hiện tại (currentPosition) và độ dài của đường đi (randomWalkParameters.walkLength). 
            Kết quả của hàm này là một tập hợp các vị trí trên đường đi.

            floorPositions.UnionWith(path): 
            Tập hợp floorPositions được mở rộng bằng cách thêm vào nó tất cả các vị trí trên đường đi (path). 
            Điều này đảm bảo rằng các vị trí trên các đường đi trước đó không bị mất đi.

            if(randomWalkParameters.startRandomlyEachInteration): 
            Điều kiện này kiểm tra xem liệu có cần bắt đầu một đường đi mới ngẫu nhiên trong mỗi lần lặp hay không.

            currentPosition = floorPositions.ElementAt(Random.Range(0,floorPositions.Count)): 
            Nếu điều kiện trên đúng, thì currentPosition được gán bằng một vị trí ngẫu nhiên trong tập hợp floorPositions. 
            Điều này đảm bảo rằng đường đi tiếp theo sẽ bắt đầu từ một vị trí ngẫu nhiên trên bản đồ.
        */
        for (int i = 0; i < randomWalkParameters.interations; i++){
            var path = ProceduralGenerationAlgorithms.SimpleRandomWalk(currentPosition, randomWalkParameters.walkLength);
            floorPositions.UnionWith(path);
            if(randomWalkParameters.startRandomlyEachInteration){
                currentPosition = floorPositions.ElementAt(Random.Range(0,floorPositions.Count));
            }
        }

        return floorPositions;
    }

}
