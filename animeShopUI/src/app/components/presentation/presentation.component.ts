import { NgFor } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { PresentationSheetModel } from '../../services/ApiClient.nswag';
import { TimeCode } from '../shared/timecode';
import { time } from 'console';

@Component({
	selector: 'ctrs-presentation',
	standalone: true,
	imports: [NgFor],
	templateUrl: './presentation.component.html',
	styleUrl: './presentation.component.scss'
})
export class PresentationComponent {
	private _presentationSheets: PresentationSheetModel[] = [];
	
	@Output()
	onSlideClick = new EventEmitter<TimeCode>();

	get presentationSheets(): PresentationSheetModel[] {
		return this._presentationSheets;
	}
	
	@Input()
	set presentationSheets(presentationSheets: PresentationSheetModel[]) {	
		this._presentationSheets = presentationSheets;
	}
	
	goToTimeCode(hours: number | undefined,
				 minutes: number | undefined, 
				 seconds: number | undefined) {
		let timeCode = new TimeCode();
		timeCode.hours = hours ?? 0;
		timeCode.minutes = minutes ?? 0;
		timeCode.seconds = seconds ?? 0;

		this.onSlideClick.emit(timeCode);
	}
}
