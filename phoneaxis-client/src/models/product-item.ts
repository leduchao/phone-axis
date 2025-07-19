export interface ProductItem {
  title: string;
  description: string;
  promotionalPrice: number;
  originalPrice: number;
  discountPercentage?: number;
  imageUrl?: string;
}
