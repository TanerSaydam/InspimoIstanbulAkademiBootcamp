import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
  selector: '[onlyNumbers]',
  standalone: true
})
export class OnlyNumbersDirective {

  private regex: RegExp = new RegExp(/^\d*[\.,]?\d*$/g); // Rakamlar, tek bir nokta veya virgül için regex
  private specialKeys: Array<string> = ['Backspace', 'Tab', 'End', 'Home', 'Delete', 'ArrowLeft', 'ArrowRight'];

  constructor(private el: ElementRef) {}

  @HostListener('keydown', ['$event'])
  onKeyDown(event: KeyboardEvent) {
    // Özel tuşlara izin ver (backspace, tab, end, home, delete, arrows)
    if (this.specialKeys.indexOf(event.key) !== -1) {
      return;
    }
    
    let current: string = this.el.nativeElement.value;
    const position = this.el.nativeElement.selectionStart;
    const next: string = [current.slice(0, position), event.key == ',' ? '.' : event.key, current.slice(position)].join('');
    if (next && !String(next).match(this.regex)) {
      event.preventDefault();
    }
  }

  @HostListener('paste', ['$event'])
  onPaste(event: ClipboardEvent) {
    event.preventDefault();
    const pastedInput: string = event.clipboardData!.getData('text/plain');
    document.execCommand('insertText', false, pastedInput.replace(/[^0-9.]/g, ''));
  }

  @HostListener('blur', ['$event.target.value'])
  onBlur(value: string) {
    this.el.nativeElement.value = value;
  }
}
