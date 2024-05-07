import { Component, Input,} from '@angular/core';
import {NgFor} from "@angular/common";
@Component({
	selector: 'ctrs-presentation-sheetlist',
	standalone: true,
	imports: [NgFor],
	templateUrl: './presentation-sheetlist.component.html',
	styleUrl: './presentation-sheetlist.component.scss'
})
export class PresentationSheetlistComponent {	

	private _imgUrls: string[] = []
	
	get imageUrls() {
		return this._imgUrls;
	}

	@Input()
	set imageUrls(imageUrls: string[]) {	
		this._imgUrls = imageUrls;
	}
}
