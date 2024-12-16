import Data.List
main :: IO ()
main = do
    input <- readFile "input.txt"
    let part1 = (sum . map (\(x:y:_) -> abs (x-y)) . transpose . map sort . transpose . map (map read . words) . lines) input
    let part2 = (sum . (\(x:y:_) -> map (\z -> z * (length . filter (==z)) y) x) . transpose . map (map read . words) . lines) input
    print part1
    print part2
