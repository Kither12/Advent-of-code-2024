import Data.List

main :: IO ()

isSafeTolerate (x : z) []
  | cntUnSafe z == 0 = 1
isSafeTolerate (x : y : z) prefix
  | cntUnSafe (prefix ++ [x] ++ z) == 0 = 1
  | otherwise = isSafeTolerate (y : z) (prefix ++ [x])
isSafeTolerate z prefix = 0

safe x
  | cntUnSafe x == 0 = 1
  | otherwise = isSafeTolerate x []

cntUnSafe (x : y : xs)
  | not (isSorted (x : y : xs)) = 1
  | abs (x - y) >= 1 && abs (x - y) <= 3 = cntUnSafe (y : xs)
  | otherwise = 1 + cntUnSafe (y : xs)
cntUnSafe x = 0

asc (x : y : xs)
  | x < y = asc (y : xs)
  | otherwise = False
asc x = True

dec x = (asc . reverse) x

isSorted x = asc x || dec x

main = do
  input <- readFile "input.txt"
  let part1 = (sum . map ((-) 1 . min 1 . cntUnSafe . map read . words) . lines) input
  let part2 = (sum . map (safe . map read . words) . lines) input
  print part1
  print part2
