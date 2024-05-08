import { Component, OnInit } from '@angular/core';
import { Product, ProductApiClient } from '../../services/ApiClient.nswag';
import { firstValueFrom } from 'rxjs';
import { CommonModule, NgFor } from '@angular/common';


@Component({
  selector: 'ctrs-suggestions',
  standalone: true,
  imports: [NgFor],
  templateUrl: './suggestions.component.html',
  styleUrl: './suggestions.component.scss'
})
export class SuggestionsComponent implements OnInit {

	private _products: Product[] = [];

	constructor(private _productApiClient: ProductApiClient) {
	}
	ngOnInit(): void {
		this._productApiClient.all()
			.toPromise()
			.then(p => {
				this._products = p as Product[];
			})
			.catch(e => console.log(e.message));
	}

	get products(): Product[] {
		return this._products;
	}

}
