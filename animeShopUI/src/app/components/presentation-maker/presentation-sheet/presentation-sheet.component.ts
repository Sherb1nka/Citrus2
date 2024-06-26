import { Component, Output, EventEmitter} from '@angular/core';

// Import all Froala Editor plugins.
import 'froala-editor/js/plugins.pkgd.min.js';

// Import a single Froala Editor plugin.
import 'froala-editor/js/plugins/align.min.js';

// Import a Froala Editor language file.
import 'froala-editor/js/languages/de.js';

// Import a third-party plugin.
import 'froala-editor/js/third_party/font_awesome.min';
import 'froala-editor/js/third_party/image_tui.min';
import 'froala-editor/js/third_party/spell_checker.min';
import 'froala-editor/js/third_party/embedly.min';
import { FroalaEditorModule, FroalaViewModule } from 'angular-froala-wysiwyg';
import { EDIT_SLIDE } from '../constants';
import html2canvas from 'html2canvas';

@Component({
	selector: 'ctrs-presentation-sheet',
	standalone: true,
	imports: [
		FroalaEditorModule,
		FroalaViewModule
	],
	templateUrl: './presentation-sheet.component.html',
	styleUrl: './presentation-sheet.component.scss'
})
export class PresentationSheetComponent {	
	
	editorContent: string = EDIT_SLIDE;

	@Output()
	onSlideSave = new EventEmitter<string>();

	saveSlide() {
		html2canvas(document.querySelector("#capture") as HTMLElement).then((canvas) => {
			let imageUrl = canvas.toDataURL("image/png");
			this.onSlideSave.emit(imageUrl);
		});
	}
}
