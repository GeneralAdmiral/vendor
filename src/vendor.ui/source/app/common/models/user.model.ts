import { Product } from './product.model';
import { Language } from './language.model';
import { ProductLanguage } from './many_to_many/product.language.model';
import { UserProduct } from './many_to_many/user.product.model';

export class User {
    image: string[];
    registerDate: string;
    // update: string;
    isBlocked: boolean;
    language: Language;
    product: Product;
    userLanguage: Language;
    userProducts: UserProduct[];
    productLanguages: ProductLanguage[];
}